<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Message, { MessageTypes } from '.';

	const id = crypto.randomUUID();
	const key = crypto.randomUUID();
	const partyId = crypto.randomUUID();

	const getEnumValues = (obj: Record<string, unknown>) =>
		Object.values(obj)
			.filter((x) => isNaN(Number(x)))
			.map((x) => `${x}`.toLocaleLowerCase());

	const neverResolves = new Promise<unknown>(() => undefined);
</script>

<Meta
	title="Components/Conversation/Message"
	component={Message}
	argTypes={{
		id: { table: { disable: true } },
		key: { table: { disable: true } },
		party: { table: { disable: true } },
		pending: {
			control: 'boolean',
		},
		timestamp: {
			control: 'date',
		},
		type: {
			control: 'inline-radio',
			options: getEnumValues(MessageTypes),
		},
		username: {
			control: 'text',
		},
	}}
/>

<Template let:args>
	<div class="flex">
		<Message
			party={{ id: partyId, name: args.username }}
			{...args}
			content={args.pending ? neverResolves : args.content}
		/>
	</div>
</Template>

<Story
	name="Message"
	args={{
		content: 'Message content.',
		id,
		key,
		pending: false,
		timestamp: new Date(),
		type: 'self',
		username: 'User',
	}}
/>
