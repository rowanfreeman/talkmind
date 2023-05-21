<script lang="ts">
	import { createEventDispatcher } from 'svelte';
	import Text from '$lib/components/Text';

	interface $$Props {
		description?: string;
		dirty?: boolean;
		disabled?: boolean;
		error?: string;
		id?: string;
		label?: string;
		maxlength?: number;
		minlength?: number;
		placeholder?: string;
		readonly?: boolean;
		required?: boolean;
		value?: string;
	}

	const dispatch = createEventDispatcher<{
		dirty: undefined;
	}>();

	export let description: $$Props['description'] = '',
		dirty: $$Props['dirty'] = false,
		disabled: $$Props['disabled'] = false,
		error: $$Props['error'] = '',
		id: $$Props['id'] = '',
		label: $$Props['label'] = '',
		maxlength: $$Props['maxlength'] = undefined,
		minlength: $$Props['minlength'] = undefined,
		placeholder: $$Props['placeholder'] = '',
		readonly: $$Props['readonly'] = false,
		required: $$Props['required'] = false,
		value: $$Props['value'] = '';

	let validationMessage = '';

	$: {
		if (value || !value) {
			validationMessage = (error || ref?.validationMessage) ?? '';
		}
	}

	let ref: HTMLInputElement | undefined;
</script>

<div class="flex flex-col gap-1">
	<label for={id}>
		<Text element="span" colour={validationMessage ? 'red' : undefined}>{label}</Text>
		{#if required}
			<Text strong element="span">*</Text>
		{/if}
		{#if description}
			<Text size="sm" class="text-neutral-500">{description}</Text>
		{/if}
	</label>
	<div
		class="flex rounded border dark:valid:data-[dirty=false]:bg-neutral-100/10 dark:valid:data-[dirty=false]:border-neutral-100/20 valid:data-[dirty=false]:bg-neutral-900/5 invalid:bg-red-500/5 valid:data-[dirty=false]:border-neutral-900/10 dark:placeholder:text-neutral-100/25 placeholder:text-neutral-900/25 focus-visible:outline-2 focus-visible:valid:outline-sky-500 focus-visible:invalid:outline-red-500 focus-visible:outline invalid:border-red-500 data-[dirty=true]:valid:border-emerald-500 data-[dirty=true]:valid:bg-emerald-500/5 dark:read-only:bg-neutral-100/10"
	>
		<input
			{disabled}
			{id}
			{maxlength}
			{minlength}
			{placeholder}
			{readonly}
			{required}
			bind:this={ref}
			bind:value
			class:cursor-not-allowed={disabled || readonly}
			class:opacity-50={disabled}
			class="bg-transparent outline-none p-2 flex-1"
			data-dirty={dirty}
			on:change
			on:focusout={() => dispatch('dirty')}
			on:input
			type="text"
		/>
	</div>
	<Text colour="red" size="sm">
		{#if validationMessage}
			{validationMessage}
		{:else}
			&nbsp;
		{/if}
	</Text>
</div>
