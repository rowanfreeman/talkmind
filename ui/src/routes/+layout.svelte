<script lang="ts">
	import App from '$lib/layouts/App';
	import app from '$lib/constants/app';
</script>

<svelte:head>
	<title>{app.appName}</title>
</svelte:head>

<App>
	<slot />
</App>
