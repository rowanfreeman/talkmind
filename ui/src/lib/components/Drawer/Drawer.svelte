<script lang="ts">
	import { fly } from 'svelte/transition';

	import Modal from '$lib/components/Modal';
	import Button from '$lib/components/Button';
	import Icon from '$lib/components/Icon';

	interface $$Props {
		open?: boolean;
	}

	export let open: $$Props['open'] = false;
</script>

<Modal bind:open on:open on:close>
	<div
		transition:fly={{ x: -380, duration: 150 }}
		class="relative bg-neutral-100 dark:bg-neutral-900 w-80"
	>
		<div class="absolute right-0 top-2">
			<div class="relative left-1/2">
				<Button variant="text" round on:click={() => (open = false)}>
					<Icon icon="XCircle" />
				</Button>
			</div>
		</div>
		<div class="flex overflow-x-hidden overflow-y-auto">
			<slot {open} />
		</div>
	</div>
</Modal>
