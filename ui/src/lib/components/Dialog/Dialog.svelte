<script lang="ts">
	import { type SvelteComponent, createEventDispatcher } from 'svelte';
	import { scale } from 'svelte/transition';
	import teleport from '$lib/directives/teleport';
	import Button from '$lib/components/Button';
	import Icon from '$lib/components/Icon';
	import Text from '$lib/components/Text';

	interface $$Props {
		footer?: string | SvelteComponent;
		open?: boolean;
		title?: string | SvelteComponent;
	}

	export let footer: $$Props['footer'] = '',
		open: $$Props['open'] = false,
		title: $$Props['title'] = '';

	const dispatch = createEventDispatcher<{ cancel: undefined }>();

	$: {
		open && !ref?.open ? ref?.showModal() : ref?.close();
	}

	let ref: HTMLDialogElement | undefined;
</script>

<dialog
	in:scale
	use:teleport={{ target: 'body' }}
	bind:this={ref}
	on:cancel|preventDefault={() => dispatch('cancel')}
	on:close
	class="relative flex flex-col drop-shadow rounded min-w-[320px] p-4 gap-4 overflow-visible text-inherit bg-inherit"
>
	<div class="absolute top-0 right-0 grid place-items-center">
		<div class="absolute">
			<Button variant="text" round on:click={() => dispatch('cancel')}>
				<Icon icon="XCircle" />
			</Button>
		</div>
	</div>
	{#if title || $$slots['title']}
		<header>
			{#if $$slots['title']}
				<slot name="title" />
			{:else if title}
				<Text size="xl" element="h1" strong>
					{title}
				</Text>
			{/if}
		</header>
	{/if}
	<main>
		<slot {ref} />
	</main>
	{#if footer || $$slots['footer']}
		<footer>
			{#if $$slots['footer']}
				<slot name="footer" />
			{:else}
				{footer}
			{/if}
		</footer>
	{/if}
</dialog>
