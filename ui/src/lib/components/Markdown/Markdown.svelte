<script lang="ts">
	import { marked } from 'marked';
	import DOMPurify from 'dompurify';
	import { onMount } from 'svelte';

	interface $$Props {
		content?: string;
	}

	let sanitise: ((source: string) => string) | undefined = undefined;

	export let content: $$Props['content'] = '';
	onMount(() => (sanitise = DOMPurify.sanitize));

	$: markdown = sanitise?.(marked(content ?? ''));
</script>

<div class="prose dark:prose-invert">
	{#if markdown}
		{@html markdown}
	{/if}
</div>
