<script lang="ts">
	import type { Placement } from '@floating-ui/dom';
	import popover from '$lib/directives/popover';

	interface $$Props {
		content?: string;
		placement?: Placement;
		ref?: HTMLElement;
	}

	export let content: $$Props['content'] = '',
		placement: $$Props['placement'] = 'top-start',
		ref: $$Props['ref'] = undefined;
</script>

<div class="contents group">
	<slot />
	{#if content && ref}
		<div
			use:popover={{ ref, placement }}
			role="tooltip"
			class="absolute w-max top-0 left-0 border-2 border-neutral-700 p-2 rounded invisible group-hover:visible opacity-0 group-hover:opacity-100 transition-opacity bg-neutral-500/10"
		>
			{content}
		</div>
	{/if}
</div>
