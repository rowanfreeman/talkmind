<script lang="ts">
	import { createEventDispatcher, onDestroy } from 'svelte';

	import Button from '$lib/components/Button';
	import type { CommonSize } from '$lib/types/size';
	import type { Duration } from 'dayjs/plugin/duration';
	import dayjs from '$lib/components/Dayjs';

	interface $$Props {
		disabled?: boolean;
		keyCode?: string;
		round?: boolean;
		size?: CommonSize;
		timeout?: Duration;
	}

	interface $$Events {
		hold: void;
		release: void;
	}

	const dispatch = createEventDispatcher<{
		hold: $$Events['hold'];
		release: $$Events['release'];
	}>();

	export let disabled: $$Props['disabled'] = false,
		keyCode: $$Props['keyCode'] = '',
		round: $$Props['round'] = false,
		size: $$Props['size'] = 'md',
		timeout: $$Props['timeout'] = dayjs.duration(10, 'seconds');

	let timeoutTimer: number | undefined = undefined;
	let isHolding = false;

	const startHolding = async () => {
		if (isHolding) return;
		isHolding = true;

		if (timeout) {
			const milliseconds = timeout.asMilliseconds();
			timeoutTimer = window.setTimeout(stopHolding, milliseconds);
		}

		await dispatch('hold');
	};

	const stopHolding = async () => {
		clearTimeout(timeoutTimer);
		if (isHolding) {
			isHolding = false;
			await dispatch('release');
		}
	};

	onDestroy(() => clearTimeout(timeoutTimer));
</script>

<svelte:window
	on:mouseup={stopHolding}
	on:keydown={async (e) => e.code === keyCode && (await startHolding())}
	on:keyup={async (e) => e.code === keyCode && (await stopHolding())}
/>

<Button on:mousedown={startHolding} {size} {round} {disabled}>
	<slot />
</Button>
