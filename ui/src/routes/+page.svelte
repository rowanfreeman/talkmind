<script lang="ts">
	import { onDestroy, onMount } from 'svelte';
	import { ChatBubbleBottomCenterText, Microphone as MicrophoneIcon } from '@steeze-ui/heroicons';

	import { useConverse } from '$lib/api/converse';
	import app from '$lib/constants/app';
	import Button from '$lib/components/Button';
	import Icon from '$lib/components/Icon';
	import PressAndHoldButton from '$lib/components/PressAndHoldButton';
	import useMediaRecorderService from '$lib/services/mediaRecorderService';
	import SignalR from '$lib/components/SignalR';
	import Microphone, { type StartRecording, type StopRecording } from '$lib/components/Microphone';
	import Conversation, {
		type Occupants,
		type Dialog,
		type Message,
	} from '$lib/components/Conversation';
	import Container from '$lib/components/Container';

	const { appName } = app;

	let recording = false;
	let speechNotRecognised = false;
	let recognisedSpeech = '';

	const { connect, connecting, disconnect, error, send, speechRecognised, speechUnrecognised } =
		useConverse();
	const mediaRecorderService = useMediaRecorderService();

	let speechRecognisedOff: (() => void) | undefined = undefined;
	let speechUnrecognisedOff: (() => void) | undefined = undefined;

	const handleStartRecording = (startRecording: StartRecording) => async () => {
		recording = true;
		speechNotRecognised = false;
		recognisedSpeech = '';

		await startRecording(async (blobEvent) => {
			const { data } = blobEvent;

			await send(data);
		});
	};

	const handleStopRecording = (stopRecording: StopRecording) => async () => {
		if (!recording) return;
		recording = false;
		stopRecording();
	};

	onMount(async () => {
		speechRecognisedOff = speechRecognised((text) => (recognisedSpeech = text));
		speechUnrecognisedOff = speechUnrecognised(() => (speechNotRecognised = true));
	});

	onDestroy(async () => {
		await disconnect();
		mediaRecorderService.stop();
		speechRecognisedOff?.();
		speechUnrecognisedOff?.();
	});

	const id1 = crypto.randomUUID();
	const id2 = crypto.randomUUID();

	const occupants: Occupants = [
		{
			id: id1,
			name: 'Me',
		},
		{
			id: id2,
			name: 'ChatGPT',
		},
	];

	let dialog: Dialog = [
		{
			content: 'Hello there',
			id: crypto.randomUUID(),
			key: crypto.randomUUID(),
			partyId: id1,
			timestamp: new Date(),
			pending: false,
		},
		{
			content: 'Hello there',
			id: crypto.randomUUID(),
			key: crypto.randomUUID(),
			partyId: id2,
			timestamp: new Date(),
			pending: false,
		},
	];
</script>

<div class="flex flex-col flex-1 items-center p-8">
	<h1 class="text-6xl">{appName}</h1>
	<Container>
		<Conversation {occupants} {dialog} />
	</Container>
	<div class="flex flex-col justify-center items-center container">
		<Microphone
			let:requestMicrophoneAccess
			let:microphoneAvailable
			let:startRecording
			let:stopRecording
			when={connect}
		>
			<SignalR connecting={$connecting} error={$error} on:reconnect={requestMicrophoneAccess}>
				{#if microphoneAvailable || microphoneAvailable === undefined}
					{@const size = 'xl'}
					<PressAndHoldButton
						on:hold={handleStartRecording(startRecording)}
						on:release={handleStopRecording(stopRecording)}
						{size}
						round
						disabled={microphoneAvailable === undefined}
						keyCode="Space"
					>
						<Icon
							src={recording ? ChatBubbleBottomCenterText : MicrophoneIcon}
							theme="solid"
							{size}
						/>
					</PressAndHoldButton>
					{#if recording}
						<p>Listening</p>
					{:else}
						<p>Press and hold to speak</p>
						{#if recognisedSpeech}
							<p><strong>{recognisedSpeech}</strong></p>
						{:else if speechNotRecognised}
							<p><strong>Sorry, I didn't understand that.</strong></p>
						{/if}
					{/if}
				{:else}
					<Button on:click={requestMicrophoneAccess}>Enable microphone</Button>
					<p>You might need to unblock microphone access.</p>
				{/if}
			</SignalR>
		</Microphone>
	</div>
</div>
