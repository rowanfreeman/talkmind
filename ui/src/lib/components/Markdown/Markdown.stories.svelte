<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Markdown from '.';
</script>

<Meta title="Components/Markdown" component={Markdown} />

<Template let:args>
	<Markdown {...args} />
</Template>

<Story name="Markdown" args={{ content: '**strong**, `code`, ~~strikethrough~~' }} />
