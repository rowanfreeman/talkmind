<script lang="ts">
	import App from '$lib/layouts/App';
	import app from '$lib/constants/app';
	import { dev } from '$app/environment';

	import DeveloperToolkit from '$lib/components/DeveloperToolkit';
</script>

<svelte:head>
	<title>{app.appName}</title>
</svelte:head>

<App>
	{#if dev}
		<DeveloperToolkit />
	{/if}
	<slot />
</App>
