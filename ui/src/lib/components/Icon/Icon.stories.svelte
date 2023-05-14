<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Icon, { icons } from '.';
	import { CommonSizes } from '$lib/types/size';

	const getEnumValues = (obj: Record<string, unknown>) =>
		Object.values(obj)
			.filter((x) => isNaN(Number(x)))
			.map((x) => `${x}`.toLocaleLowerCase());
</script>

<Meta
	title="Components/Icon"
	component={Icon}
	argTypes={{
		icon: {
			control: 'select',
			options: icons,
		},
		size: {
			control: 'inline-radio',
			options: getEnumValues(CommonSizes),
		},
		theme: {
			control: 'inline-radio',
			options: ['outline', 'solid', 'mini'],
		},
	}}
/>

<Template let:args>
	<Icon {...args} />
</Template>

<Story
	name="Icon"
	args={{ icon: icons.find((x) => x === 'Cog6Tooth'), size: 'md', theme: 'solid' }}
/>
