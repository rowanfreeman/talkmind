<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Avatar from '.';
	import { CommonSizes } from '$lib/types/size';
	import { Colours } from '$lib/types/colour';

	const getEnumValues = (obj: Record<string, unknown>) =>
		Object.values(obj)
			.filter((x) => isNaN(Number(x)))
			.map((x) => `${x}`.toLocaleLowerCase());
</script>

<Meta
	title="Components/Avatar"
	component={Avatar}
	argTypes={{
		content: {
			control: 'text',
		},
		size: {
			control: 'inline-radio',
			options: getEnumValues(CommonSizes),
		},
		variant: {
			control: 'inline-radio',
			options: ['round', 'rounded', 'square'],
		},
		colour: {
			control: 'select',
			options: getEnumValues(Colours),
		},
	}}
/>

<Template let:args>
	<Avatar {...args}>
		{args.content}
	</Avatar>
</Template>

<Story name="Avatar" args={{ colour: 'sky', content: 'A', size: 'md', variant: 'round' }} />
