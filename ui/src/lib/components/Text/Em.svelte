<script lang="ts">
	interface $$Props {
		emphasis?: boolean;
	}

	export let emphasis: $$Props['emphasis'] = false;
</script>

{#if emphasis}
	<em class="italic"><slot /></em>
{:else}
	<slot />
{/if}
