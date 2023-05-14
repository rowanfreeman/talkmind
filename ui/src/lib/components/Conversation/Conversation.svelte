<script lang="ts">
	import type { Dialog, Occupants } from '.';
	import Message from '$lib/components/Conversation/Message';

	interface $$Props {
		occupants?: Occupants;
		dialog: Dialog;
	}

	export let dialog: $$Props['dialog'] = [],
		occupants: $$Props['occupants'] = undefined;
</script>

<div class="flex flex-col gap-4">
	{#each dialog as message}
		{@const index = occupants?.findIndex((x) => x.id === message.partyId) ?? 0}
		{@const party = occupants?.at(index)}
		<Message
			key={message.key}
			{party}
			type={index === 0 ? 'self' : 'other'}
			content={message.content}
			id={message.id}
		/>
	{/each}
	<slot />
</div>
