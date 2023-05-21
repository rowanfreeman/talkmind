<script lang="ts">
	interface $$Props {
		strong?: boolean;
	}

	export let strong: $$Props['strong'] = false;
</script>

{#if strong}
	<strong class="font-bold"><slot /></strong>
{:else}
	<slot />
{/if}
