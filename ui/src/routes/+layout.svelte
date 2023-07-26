<script lang="ts">
	import Shell from '$lib/layouts/Shell';
	import app from '$lib/constants/app';
</script>

<svelte:head>
	<title>{app.appName}</title>
</svelte:head>

<Shell>
	<slot />
</Shell>
