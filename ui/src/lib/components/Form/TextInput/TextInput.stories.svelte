<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import TextInput from '.';

	let dirty = false;
</script>

<Meta title="Components/Form/TextInput" component={TextInput} argTypes={{}} />

<Template let:args>
	<div class="max-w-xs">
		<TextInput {...args} {dirty} on:dirty={() => (dirty = true)} />
	</div>
</Template>

<Story
	name="TextInput"
	args={{
		description: 'This is your username',
		dirty,
		disabled: false,
		error: '',
		id: 'username',
		label: 'Username',
		maxlength: '',
		minlength: '',
		placeholder: 'Username',
		readonly: false,
		required: false,
		value: 'User',
	}}
/>
