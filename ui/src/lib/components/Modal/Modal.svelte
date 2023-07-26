<script lang="ts">
	import { createEventDispatcher } from 'svelte';
	import teleport from '$lib/directives/teleport';

	interface $$Props {
		open?: boolean;
	}

	const dispatch = createEventDispatcher<{
		open: unknown;
		close: unknown;
	}>();

	export let open: $$Props['open'] = false;

	$: {
		open ? dispatch('open') : dispatch('close');
	}
</script>

<svelte:window on:keydown={({ key }) => key === 'Escape' && open && (open = false)} />

{#if open}
	<div
		use:teleport={{ target: 'body' }}
		class="absolute inset-0 flex bg-black/25 text-neutral-900 dark:text-neutral-100"
		on:click|self={() => (open = false)}
		on:keydown={({ code }) => code === 'Escape' && open && (open = false)}
		role="presentation"
	>
		<slot {open} />
	</div>
{/if}
