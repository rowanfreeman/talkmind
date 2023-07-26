<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Conversation, {ConversationProvider} from '.';
	import { EventBusProvider, type SpeechRecognitionStartedEvent, type EventBus } from '$lib/components/EventBus';
	import Button from '$lib/components/Button';

	const occupant1Id = crypto.randomUUID();
	const occupant2Id = crypto.randomUUID();

	const handleGenerateMessage = (publish: EventBus['publish'], partyId: string) => () => {
		const content = new Promise<string>((res) => setTimeout(() => res('Hello world'), 1000));

		publish<SpeechRecognitionStartedEvent>('speechRecognitionStarted', { id: crypto.randomUUID(), partyId, content });
	}
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
	<EventBusProvider let:publish>
		<ConversationProvider let:dialog>
			<div>
				<Button colour="sky" iconLeft="ChatBubbleLeft" on:click={handleGenerateMessage(publish, occupant1Id)}>
					Generate message for {args.occupant1}
				</Button>
				<Button colour="emerald" iconLeft="ChatBubbleLeft" on:click={handleGenerateMessage(publish, occupant2Id)}>
					Generate message for {args.occupant2}
				</Button>
				<Button colour="rose" iconLeft="ArrowPath">Reset</Button>
			</div>
			<Conversation
				occupants={[
					{ id: occupant1Id, name: args.occupant1 },
					{ id: occupant2Id, name: args.occupant2 },
				]}
				{dialog}
			/>
		</ConversationProvider>
	</EventBusProvider>
</Template>

<Story name="Conversation" args={{ occupant1: 'User 1', occupant2: 'User 2' }} />
