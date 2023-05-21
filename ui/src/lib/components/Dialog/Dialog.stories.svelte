<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';

	import Dialog, { ActionDialog, dialogManager, Dialogs } from '.';
	import Button from '$lib/components/Button';
	import Text from '$lib/components/Text';

	let result = '';

	const handleOpenDialog = async () => {
		result = await dialogManager.open<ActionDialog<string>>(ActionDialog, {
			content: 'What do you think?',
			actions: [
				{
					iconLeft: 'Check',
					content: 'Ok',
					onClick: async ({ close }) => close('Clicked ok!'),
					colour: 'emerald',
				},
				{
					content: 'Cancel',
					onClick: async ({ cancel }) => cancel(),
					variant: 'text',
				},
			],
		});
	};
</script>

<Meta title="Components/Dialog" component={Dialog} />

<Template id="Dialog">
	<Dialog open title="Title" footer="Footer">Body</Dialog>
</Template>

<Template id="InteractiveDialog">
	<Button colour="sky" on:click={handleOpenDialog} iconRight="Plus">Open Dialog</Button>
	<Text>{result ? result : ''}</Text>
	<Dialogs />
</Template>

<Template id="ActionDialog">
	<ActionDialog
		title="A dialog with buttons"
		open
		actions={[
			{
				content: 'Send',
				colour: 'sky',
				iconLeft: 'PaperAirplane',
			},
			{
				content: 'Cancel',
				variant: 'text',
			},
		]}
	>
		<p>Would you like to send a message?</p>
	</ActionDialog>
</Template>

<Story name="Dialog" template="Dialog" />
<Story name="Interactive" template="InteractiveDialog" />
<Story name="Action Dialog" template="ActionDialog" />
