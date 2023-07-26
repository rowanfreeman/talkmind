<script lang="ts">
	import { getContext, onMount, onDestroy, createEventDispatcher } from 'svelte';
	import type {
		EventBus,
		ApplicationEvent,
		ConnectEvent,
		DisconnectEvent,
		SpeechRecognitionStartedEvent,
	} from '$lib/components/EventBus';

	interface $$Events {
		connect: ConnectEvent['args'];
		disconnect: DisconnectEvent['args'];
		speechRecognitionStarted: SpeechRecognitionStartedEvent['args'];
	}

	const dispatch = createEventDispatcher<$$Events>();

	const eventBus = getContext<EventBus>('EventBus');

	const handleEvent = (event: ApplicationEvent) => {
		dispatch(event.name, event.args as void);
	};

	let unsubscribe: VoidFunction | undefined;

	onMount(() => (unsubscribe = eventBus.subscribe(handleEvent)));
	onDestroy(() => unsubscribe?.());
</script>

<slot />
