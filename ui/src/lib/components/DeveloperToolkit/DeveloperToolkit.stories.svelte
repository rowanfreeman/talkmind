<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import DeveloperToolkit, { DeveloperToolkitToggle } from '.';
	import Drawer from '$lib/components/Drawer';

	let open = false;
</script>

<Meta title="Components/DeveloperToolkit" component={DeveloperToolkit} />

<Template id="DeveloperToolkit">
	<DeveloperToolkit />
</Template>

<Template id="DeveloperToolkitFullExample">
	<DeveloperToolkitToggle on:click={() => (open = !open)} />
	<Drawer bind:open>
		<div class="p-4">
			<DeveloperToolkit />
		</div>
	</Drawer>
</Template>

<Story name="DeveloperToolkit" template="DeveloperToolkit" />

<Story name="DeveloperToolkit Full Example" template="DeveloperToolkitFullExample" />
