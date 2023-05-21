<script lang="ts">
	import { createEventDispatcher, type SvelteComponent } from 'svelte';
	import Dialog from '$lib/components/Dialog';
	import Button from '$lib/components/Button';
	import type { ButtonDescriptor } from '.';

	type TResult = $$Generic;

	interface $$Props {
		actions?: ButtonDescriptor<TResult>[];
		open?: boolean;
		title?: string | SvelteComponent;
		content?: string | SvelteComponent;
	}

	const dispatch = createEventDispatcher<{
		close: TResult;
		cancel: undefined;
	}>();

	interface $$Events extends Record<string, unknown> {
		close: TResult;
	}

	export let actions: $$Props['actions'] = [],
		content: $$Props['content'] = '',
		open: $$Props['open'] = false,
		title: $$Props['title'] = '';
</script>

<Dialog {open} {title} on:close on:cancel let:ref>
	<slot name="title" />
	{#if content}
		{content}
	{:else}
		<slot />
	{/if}
	<svelte:fragment slot="footer">
		<div class="flex justify-end gap-4">
			{#each actions ?? [] as action}
				<Button
					{...action}
					on:click={() =>
						action.onClick?.({
							cancel: () => dispatch('cancel'),
							close: (value) => {
								ref?.close();
								dispatch('close', value);
							},
						})}
				>
					{action.content}
				</Button>
			{/each}
		</div>
	</svelte:fragment>
</Dialog>
