<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import PasswordInput from '.';
	import { icons } from '$lib/components/Icon';
</script>

<Meta
	title="Components/Form/TextInput/PasswordInput"
	component={PasswordInput}
	argTypes={{
		iconLeft: {
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
		<PasswordInput {...args} />
	</div>
</Template>

<Story
	name="PasswordInput"
	args={{
		description: 'Enter in your password',
		dirty: false,
		disabled: false,
		error: '',
		iconLeft: '',
		id: 'password',
		label: 'Password',
		maxlength: '',
		minlength: '',
		placeholder: 'Password',
		readonly: false,
		required: false,
		value: 'secret',
	}}
/>
