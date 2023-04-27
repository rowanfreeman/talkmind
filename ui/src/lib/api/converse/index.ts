import { readonly, writable } from 'svelte/store';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { PUBLIC_API_URL } from '$env/static/public';

const toBase64 = (blob: Blob) =>
	new Promise<string>((resolve) => {
		const reader = new FileReader();
		reader.onload = (event) => {
			const result = (event.target?.result ?? '') as string;
			const [, base64] = result.split(',');

			resolve(base64);
		};
		reader.readAsDataURL(blob);
	});

const build = (url: string) =>
	new HubConnectionBuilder().withUrl(url).withAutomaticReconnect().build();

const useConverse = () => {
	const connection = build(`${PUBLIC_API_URL}/hubs/converse`);
	const connecting = writable(true);
	const connectionError = writable<Error | undefined>(undefined);

	connection.onreconnected(() => {
		connecting.set(false);
		connectionError.set(undefined);
	});

	connection.onreconnecting((error) => {
		connecting.set(true);
		connectionError.set(error);
	});

	connection.onclose(() => {
		connecting.set(false);
		connectionError.set(new Error('Unable to connect'));
	});

	const connect = async () => {
		try {
			connecting.set(true);
			connectionError.set(undefined);
			await connection.start();
			return true;
		} catch (error) {
			connectionError.set(error as Error);
			return false;
		} finally {
			connecting.set(false);
		}
	};

	const disconnect = async () => await connection.stop();

	const send = async (payload: Blob) => {
		const encodedBytes = await toBase64(payload);

		try {
			await connection.send('Converse', encodedBytes);
		} catch (err) {
			connectionError.set(err as Error);
		}
	};

	const speechRecognised = (callback: (text: string) => void) => {
		connection.on('SpeechRecognised', (text) => callback(text));

		return () => connection.off('SpeechRecognised');
	};

	const speechUnrecognised = (callback: () => void) => {
		connection.on('SpeechUnrecognised', callback);

		return () => connection.off('SpeechUnrecognised');
	};

	return {
		connect,
		connecting: readonly(connecting),
		disconnect,
		error: readonly(connectionError),
		send,
		speechRecognised,
		speechUnrecognised,
	};
};

export { useConverse };
