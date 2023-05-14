<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Drawer from '.';
	import Button from '$lib/components/Button';

	let open = false;
</script>

<Meta title="Components/Drawer" component={Drawer} />

<Template let:args>
	<Drawer {...args} bind:open>
		<div class="p-4">This is a drawer.</div>
	</Drawer>
	<Button colour="sky" on:click={() => (open = true)}>Open Drawer</Button>
</Template>

<Story name="Drawer" args={{ open: false }} />
