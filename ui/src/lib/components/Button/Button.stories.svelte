<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Button from '.';
	import { CommonSizes } from '$lib/types/size';
	import { Colours } from '$lib/types/colour';

	const getEnumValues = (obj: Record<string, unknown>) =>
		Object.values(obj)
			.filter((x) => isNaN(Number(x)))
			.map((x) => `${x}`.toLocaleLowerCase());
</script>

<Meta
	title="Components/Button"
	component={Button}
	argTypes={{
		colour: {
			control: 'select',
			options: getEnumValues(Colours),
		},
		size: {
			control: 'inline-radio',
			options: getEnumValues(CommonSizes),
		},
	}}
/>

<Template let:args>
	<Button {...args}>
		{args.content ?? ''}
	</Button>
</Template>

<Story name="Button" args={{ content: 'Button', disabled: false, round: false, size: 'md' }} />
