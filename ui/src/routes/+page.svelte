<script lang="ts">
	import app from '$lib/constants/app';
	import Conversation, {
		type Occupants,
		type Dialog,
	} from '$lib/components/Conversation';
	import Container from '$lib/components/Container';

	const { appName } = app;

	const id1 = crypto.randomUUID();
	const id2 = crypto.randomUUID();

	const occupants: Occupants = [
		{
			id: id1,
			name: 'Me',
		},
		{
			id: id2,
			name: 'TalkMind',
		},
	];

	let dialog: Dialog = [
		{
			content: new Promise((res) => setTimeout(() => res('Hello there.'), 500)),
			id: crypto.randomUUID(),
			key: crypto.randomUUID(),
			partyId: id1,
			timestamp: new Date(),
		},
		{
			content: new Promise((res) => setTimeout(() => res('Hi.'), 1000)),
			id: crypto.randomUUID(),
			key: crypto.randomUUID(),
			partyId: id2,
			timestamp: new Date(),
		},
	];
</script>

<div class="flex flex-col flex-1 items-center p-8">
	<h1 class="text-6xl">{appName}</h1>
	<Container>
		<Conversation {occupants} {dialog} />
	</Container>
</div>
