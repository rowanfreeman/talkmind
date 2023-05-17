<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Tooltip from '.';
	import type { Placement } from '@floating-ui/dom';

	const placements = [
		'bottom',
		'bottom-end',
		'bottom-start',
		'left',
		'left-end',
		'left-start',
		'right',
		'right-end',
		'right-start',
		'top',
		'top-end',
		'top-start',
	] satisfies Placement[];

	let ref: HTMLElement | undefined = undefined;
</script>

<Meta
	title="Components/Tooltip"
	component={Tooltip}
	argTypes={{
		placement: {
			control: 'select',
			options: placements,
		},
		ref: { table: { disable: true } },
	}}
/>

<Template let:args>
	<Tooltip {...args} {ref}>
		<div class="flex">
			<p bind:this={ref}>This text has a tooltip.</p>
		</div>
	</Tooltip>
</Template>

<Story name="Tooltip" args={{ content: 'Tooltip example', placement: 'bottom' }} />
