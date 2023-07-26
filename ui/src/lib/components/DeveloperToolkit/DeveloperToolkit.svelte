<script lang="ts">
	import Button from '$lib/components/Button';
	import Text from '$lib/components/Text';

	import { useEventBus, type ConnectEvent, type DisconnectEvent } from '$lib/components/EventBus';

	const eventBus = useEventBus();

	const handleConnect = async () => {
		await eventBus.publish<ConnectEvent>('connect');
	};

	const handleDisconnect = async () => {
		await eventBus.publish<DisconnectEvent>('disconnect');
	};
</script>

<div class="flex flex-col gap-4">
	<Text element="h1">Connection</Text>
	<div class="flex flex-wrap gap-4">
		<Button colour="emerald" iconLeft="Bolt" on:click={handleConnect}>Connect</Button>
		<Button colour="red" iconLeft="BoltSlash" on:click={handleDisconnect}>Disconnect</Button>
	</div>
	<Text element="h1">Simulator</Text>
	<div class="flex flex-wrap gap-4">
		<Button colour="sky">New</Button>
		<Button colour="emerald">Test</Button>
	</div>
</div>
