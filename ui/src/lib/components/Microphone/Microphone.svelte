<script lang="ts">
	import { onMount } from 'svelte';

	import useMediaRecorderService from '$lib/services/mediaRecorderService';

	interface $$Props {
		when?: () => Promise<boolean>;
	}

	export let when: $$Props['when'] = undefined;

	let microphoneAvailable: boolean | undefined = undefined;

	const mediaRecorderService = useMediaRecorderService();

	onMount(async () => {
		await requestMicrophoneAccess();
	});

	const requestMicrophoneAccess = async () => {
		if (await when?.()) microphoneAvailable = await mediaRecorderService.requestMicrophoneAccess();
	};
</script>

<slot
	startRecording={mediaRecorderService.start}
	stopRecording={mediaRecorderService.stop}
	{microphoneAvailable}
	{requestMicrophoneAccess}
/>
