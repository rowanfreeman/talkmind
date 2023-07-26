<script lang="ts">
	import { setContext } from 'svelte';
	import type { ApplicationEvent, Callback, EventBus } from '$lib/components/EventBus';

	const handlers = new Map<symbol, Callback<ApplicationEvent>>();

	const eventBus: EventBus = {
		publish: async <TEvent extends ApplicationEvent>(
			eventName: TEvent['name'],
			args?: TEvent['args'],
		) => handlers.forEach((callback) => callback({ name: eventName, args })),
		subscribe: (callback) => {
			const key = Symbol();
			handlers.set(key, callback);
			return () => handlers.delete(key);
		},
	};

	setContext<EventBus>('EventBus', eventBus);
</script>

<slot publish={eventBus.publish} />
