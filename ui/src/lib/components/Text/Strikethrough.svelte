<script lang="ts">
	interface $$Props {
		strikethrough?: boolean;
	}

	export let strikethrough: $$Props['strikethrough'] = false;
</script>

{#if strikethrough}
	<s><slot /></s>
{:else}
	<slot />
{/if}
