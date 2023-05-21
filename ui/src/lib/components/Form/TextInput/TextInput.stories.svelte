<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import TextInput, { InputTypes } from '.';
	import { icons } from '$lib/components/Icon';

	const getEnumValues = (obj: Record<string, unknown>) =>
		Object.values(obj)
			.filter((x) => isNaN(Number(x)))
			.map((x) => `${x}`.toLocaleLowerCase());
</script>

<Meta
	title="Components/Form/TextInput"
	component={TextInput}
	argTypes={{
		type: {
			control: 'inline-radio',
			options: getEnumValues(InputTypes),
		},
		iconLeft: {
			control: 'select',
			options: icons,
		},
		iconRight: {
			control: 'select',
			options: icons,
		},
		maxlength: {
			control: 'number',
		},
		minlength: {
			control: 'number',
		},
	}}
/>

<Template let:args>
	<div class="max-w-xs">
		<TextInput {...args} />
	</div>
</Template>

<Story
	name="TextInput"
	args={{
		description: 'This is your username',
		dirty: false,
		disabled: false,
		error: '',
		iconLeft: '',
		iconRight: '',
		id: 'username',
		label: 'Username',
		maxlength: '',
		minlength: '',
		placeholder: 'Username',
		readonly: false,
		required: false,
		type: 'text',
		value: 'User',
	}}
/>
