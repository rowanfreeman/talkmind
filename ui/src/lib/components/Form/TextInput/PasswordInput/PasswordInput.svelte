<script lang="ts">
	import TextInput, { type TextInputProps } from '$lib/components/Form/TextInput';
	import Button from '$lib/components/Button';
	import Icon from '$lib/components/Icon';

	interface $$Props extends Omit<TextInputProps, 'type' | 'iconRight'> {}

	let showPassword = false;
</script>

<TextInput type={showPassword ? 'text' : 'password'} {...$$restProps}>
	<svelte:fragment slot="right">
		<Button on:click={() => (showPassword = !showPassword)} variant="text" size="sm" round>
			<Icon icon={showPassword ? 'EyeSlash' : 'Eye'} />
		</Button>
	</svelte:fragment>
</TextInput>
