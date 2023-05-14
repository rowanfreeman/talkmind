<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Button from '$lib/components/Button';
	import Modal from '.';

	let open = false;
</script>

<Meta title="Components/Modal" component={Modal} />

<Template let:args>
	<Modal
		open={args.open || open}
		on:open={() => (open = !args.open)}
		on:close={() => (open = args.open)}
	/>
	<Button colour="sky" on:click={() => (open = true)}>Open Modal</Button>
</Template>

<Story name="Modal" args={{ open }} />
