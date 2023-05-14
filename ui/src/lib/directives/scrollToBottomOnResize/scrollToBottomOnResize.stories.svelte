<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Button from '$lib/components/Button';
	import Message from '$lib/components/Conversation/Message';
	import scrollToBottomOnResize from '.';

	let messages: string[] = [];

	const addMesage = () => (messages = [...messages, crypto.randomUUID()]);
</script>

<Meta title="Directives/scrollToBottomOnResize" />

<Template>
	<div class="relative flex flex-col" use:scrollToBottomOnResize>
		<div class="fixed inset-0 flex flex-row-reverse h-fit p-8">
			<Button on:click={addMesage} colour="sky">Add new message</Button>
		</div>
		<div class="flex flex-col gap-8">
			{#each messages as message}
				<Message
					content={message}
					id={message}
					key={message}
					party={{ id: message, name: 'Example' }}
					type="other"
				/>
			{/each}
		</div>
	</div>
</Template>

<Story name="scrollToBottomOnResize" />
