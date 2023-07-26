<script lang="ts">
	import '$lib/assets/styles/app.pcss';
	import { dev } from '$app/environment';
	import { PUBLIC_DEV_TOOLKIT } from '$env/static/public';

	import DeveloperToolkit from '$lib/components/DeveloperToolkit';
	import Drawer from '$lib/components/Drawer';
	import DeveloperToolkitToggle from '$lib/components/DeveloperToolkit/DeveloperToolkitToggle';
	import { EventBusProvider } from '$lib/components/EventBus';

	let open = false;
	const developerToolkit = dev && PUBLIC_DEV_TOOLKIT === 'true';
</script>

<EventBusProvider>
	<div class="flex-1 bg-neutral-100 text-neutral-900 dark:bg-neutral-900 dark:text-neutral-100">
		{#if developerToolkit}
			<div class="fixed top-10 left-10">
				<DeveloperToolkitToggle on:click={() => (open = true)} />
			</div>
			<Drawer bind:open>
				<div class="p-4">
					<DeveloperToolkit />
				</div>
			</Drawer>
		{/if}
		<slot />
	</div>
</EventBusProvider>

<style lang="postcss">
	:global(body) {
		@apply min-h-screen overflow-scroll flex flex-col;
	}
</style>
