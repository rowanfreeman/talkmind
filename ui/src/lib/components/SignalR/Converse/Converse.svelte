<script lang="ts">
	import { createEventDispatcher } from 'svelte';
	import { ArrowPath } from '@steeze-ui/heroicons';

	import Button from '$lib/components/Button';
	import Icon from '$lib/components/Icon';
	import Loader from '$lib/components/Loader';

	interface $$Props {
		connecting?: boolean;
		error?: Error;
	}

	const dispatch = createEventDispatcher<{ reconnect: Promise<void> }>();

	export let connecting: $$Props['connecting'] = true,
		error: $$Props['error'] = undefined;

	const handleClick = () => dispatch('reconnect');
</script>

{#if connecting}
	<Loader size="xl" />
{:else if error}
	<Button on:click={handleClick}>
		<Icon src={ArrowPath} theme="solid" />
		Reconnect
	</Button>
{:else}
	<slot />
{/if}
