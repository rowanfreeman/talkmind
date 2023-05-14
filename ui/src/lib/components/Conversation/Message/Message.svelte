<script lang="ts">
	import { fly } from 'svelte/transition';

	import type { MessageId, Party, Content } from '$lib/components/Conversation';
	import Avatar from '$lib/components/Avatar';
	import DateTime from '$lib/components/DateTime';
	import Markdown from '$lib/components/Markdown';
	import Icon from '$lib/components/Icon';
	import type { MessageType } from '.';

	interface $$Props {
		content: Content | Promise<Content>;
		id: MessageId;
		key: string;
		party?: Party;
		timestamp?: Date;
		type?: MessageType;
	}

	export let content: $$Props['content'] = '',
		id: $$Props['id'],
		key: $$Props['key'],
		party: $$Props['party'] = { id: '', name: '' },
		timestamp: $$Props['timestamp'] = new Date(),
		type: $$Props['type'] = 'self';

	$: self = type === 'self';
</script>

<div
	class="flex gap-4"
	data-message-id={id}
	class:flex-row-reverse={self}
	transition:fly={{ x: self ? 50 : -50 }}
>
	{#key key}
		<div class="flex">
			<Avatar colour={self ? 'sky' : 'emerald'}>
				{party?.name?.[0] ?? '?'}
			</Avatar>
		</div>
		<div class="flex flex-col gap-2">
			<div class="flex gap-4 items-baseline" class:flex-row-reverse={self}>
				<p>
					{party?.name}
				</p>
				<small class="text-neutral-900/50 dark:text-neutral-100/50">
					<DateTime format="LT" value={timestamp} />
				</small>
			</div>
			<div class="relative flex" class:justify-end={self}>
				{#await content}
					<div class="absolute border-2 p-2 prose dark:prose-invert flex items-center invisible">
						&nbsp;
						<div class="animate-pulse visible">
							<Icon icon="ChatBubbleLeftEllipsis" />
						</div>
					</div>
				{:then content}
					<div transition:fly={{ y: -25 }}>
						<div
							class={`border-2 p-2 rounded-xl min-w-[64px] ${
								self ? 'bg-sky-500/10 border-sky-500' : 'bg-emerald-500/10 border-emerald-500'
							}`}
						>
							<Markdown {content} />
						</div>
					</div>
				{:catch}
					<p>Error</p>
				{/await}
			</div>
		</div>
	{/key}
</div>
