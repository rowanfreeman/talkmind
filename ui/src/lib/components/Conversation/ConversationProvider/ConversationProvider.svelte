<script lang="ts">
	import type { Dialog, Occupants } from '$lib/components/Conversation';
	import EventBus, { type SpeechRecognitionStartedEvent } from '$lib/components/EventBus';

	let dialog: Dialog = [];
	let occupants: Occupants = [
		{ id: crypto.randomUUID(), name: '' },
		{ id: crypto.randomUUID(), name: '' },
	];

	const handleSpeechRecognitionStarted = (args: SpeechRecognitionStartedEvent['args']) => {
		dialog = [...dialog, { ...args!, key: args?.id ?? '', timestamp: new Date() }];
	};
</script>

<EventBus on:speechRecognitionStarted={handleSpeechRecognitionStarted}>
	<slot {dialog} {occupants} />
</EventBus>
