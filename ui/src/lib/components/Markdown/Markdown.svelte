<script lang="ts">
	import * as marked from 'marked';
	import DOMPurify from 'dompurify';
	import { onMount } from 'svelte';

	interface $$Props {
		content?: string;
	}

	let sanitise: (source: string) => string;

	export let content: $$Props['content'] = '';
	onMount(() => (sanitise = DOMPurify.sanitize));

	$: markdown = sanitise?.(marked.marked(content ?? ''));
</script>

<div class="prose dark:prose-invert">
	{#if markdown}
		{@html markdown}
	{/if}
</div>
