<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Conversation from '.';
</script>

<Meta
	title="Components/Conversation"
	component={Conversation}
	argTypes={{
		occupants: { table: { disable: true } },
		dialog: { table: { disable: true } },
		occupant1: {
			control: 'text',
		},
		occupant2: {
			control: 'text',
		},
	}}
/>

<Template let:args>
	<Conversation
		occupants={[
			{ id: crypto.randomUUID(), name: args.occupant1 },
			{ id: crypto.randomUUID(), name: args.occupant2 },
		]}
		dialog={[]}
	/>
</Template>

<Story name="Conversation" args={{ occupant1: 'User 1', occupant2: 'User 2' }} />
