<script lang="ts">
	import '$lib/assets/styles/app.pcss';
</script>

<div class="flex-1 bg-neutral-100 text-neutral-900 dark:bg-neutral-900 dark:text-neutral-100">
	<slot />
</div>

<style lang="postcss">
	:global(body) {
		@apply min-h-screen overflow-scroll flex flex-col;
	}
</style>
