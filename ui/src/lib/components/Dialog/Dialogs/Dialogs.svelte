<script lang="ts">
	import dialogStore from '$lib/components/Dialog/stores/dialogStore';
</script>

{#each [...$dialogStore] as [key, dialog]}
	{#key key}
		<svelte:component
			this={dialog.component}
			{...dialog.props}
			on:cancel={(event) => {
				dialog.resolve(event.detail);
				dialogStore.update((x) => {
					x.delete(key);
					return x;
				});
			}}
			on:close={(event) => {
				dialog.resolve(event.detail);
				dialogStore.update((x) => {
					x.delete(key);
					return x;
				});
			}}
		/>
	{/key}
{/each}
