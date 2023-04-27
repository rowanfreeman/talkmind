<script lang="ts">
	import { fly, slide } from 'svelte/transition';
	import { quintOut } from 'svelte/easing';

	import type { MessageId, Party, Content } from '$lib/components/Conversation';
	import Avatar from '$lib/components/Avatar';
	import DateTime from '$lib/components/DateTime';
	import Markdown from '$lib/components/Markdown';
	import Icon from '$lib/components/Icon';

	enum MessageTypes {
		Self,
		Other,
	}

	type MessageType = Lowercase<keyof typeof MessageTypes>;

	interface $$Props {
		content: Content;
		id: MessageId;
		key: string;
		party?: Party;
		pending?: boolean;
		timestamp?: Date;
		type?: MessageType;
	}

	export let content: $$Props['content'] = '',
		id: $$Props['id'],
		key: $$Props['key'],
		party: $$Props['party'] = { id: '', name: '' },
		pending: $$Props['pending'] = true,
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
				{party?.name.at(0)}
			</Avatar>
		</div>
		<div class="flex flex-col gap-2 max-w-[60%]">
			<div class="flex gap-4 items-baseline" class:flex-row-reverse={self}>
				<p>
					{party?.name}
				</p>
				<small class="text-black/50 dark:text-white/50">
					<DateTime format="LT" value={timestamp} />
				</small>
			</div>
			<div class="relative flex" class:justify-end={self}>
				{#if pending}
					<div class="absolute border-2 p-2 prose dark:prose-invert flex items-center invisible">
						&nbsp;
						<div class="animate-pulse visible">
							<Icon icon="ChatBubbleLeftEllipsis" />
						</div>
					</div>
				{:else}
					<div transition:fly={{ y: -25 }}>
						<p
							class={`border-2 p-2 rounded-xl min-w-[64px] ${
								self ? 'bg-sky-500/10 border-sky-500' : 'bg-emerald-500/10 border-emerald-500'
							}`}
						>
							<Markdown {content} />
						</p>
					</div>
				{/if}
			</div>
		</div>
	{/key}
</div>
