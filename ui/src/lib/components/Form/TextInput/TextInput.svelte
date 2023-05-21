<script lang="ts">
	import { afterUpdate, createEventDispatcher } from 'svelte';
	import type { Action } from 'svelte/action';

	import Icon from '$lib/components/Icon';
	import Text from '$lib/components/Text';
	import type { InputType, TextInputProps } from '.';

	const dispatch = createEventDispatcher<{ dirty: undefined }>();

	export let description: TextInputProps['description'] = '',
		dirty: TextInputProps['dirty'] = false,
		disabled: TextInputProps['disabled'] = false,
		error: TextInputProps['error'] = '',
		iconLeft: TextInputProps['iconLeft'] = undefined,
		iconRight: TextInputProps['iconRight'] = undefined,
		id: TextInputProps['id'] = '',
		label: TextInputProps['label'] = '',
		maxlength: TextInputProps['maxlength'] = undefined,
		minlength: TextInputProps['minlength'] = undefined,
		placeholder: TextInputProps['placeholder'] = '',
		readonly: TextInputProps['readonly'] = false,
		required: TextInputProps['required'] = false,
		type: TextInputProps['type'] = 'text',
		value: TextInputProps['value'] = '';

	let validationMessage = '';

	$: {
		error ? ref?.setCustomValidity(error) : ref?.setCustomValidity('');
	}

	afterUpdate(() => {
		ref?.checkValidity();
		validationMessage = (error || ref?.validationMessage) ?? '';
	});

	const inputType: Action<HTMLInputElement, { type: InputType }> = (node, props) => {
		node.type = props?.type ?? 'text';
		return {
			update: (props) => (node.type = props.type),
		};
	};

	let ref: HTMLInputElement | undefined;
</script>

<div class="flex flex-col gap-1">
	<fieldset class="flex flex-col gap-1 group">
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
			class="flex p-2 gap-2 items-center rounded border focus-within:outline outline-2 border-neutral-500 dark:group-valid:data-[dirty=false]:bg-neutral-100/5 group-valid:data-[dirty=false]:bg-neutral-900/5 group-invalid:bg-red-500/10 group-invalid:border-red-500 group-valid:outline-sky-500 group-valid:focus-within:border-sky-500 group-invalid:outline-red-500 group-valid:data-[dirty=true]:bg-emerald-500/10 group-valid:data-[dirty=true]:border-emerald-500 group-valid:data-[dirty=true]:outline-emerald-500"
			data-dirty={dirty}
		>
			<slot name="left">
				{#if iconLeft}
					<div>
						<Icon icon={iconLeft} />
					</div>
				{/if}
			</slot>
			<input
				{disabled}
				{id}
				{maxlength}
				{minlength}
				{placeholder}
				{readonly}
				{required}
				use:inputType={{ type: type ?? 'text' }}
				bind:this={ref}
				bind:value
				class:cursor-not-allowed={disabled || readonly}
				class:opacity-50={disabled}
				class="bg-transparent outline-none flex-1 dark:placeholder:text-neutral-100/25 placeholder:text-neutral-900/25 invalid:text-red-500"
				on:change
				on:focusout={() => dispatch('dirty')}
				on:input
			/>
			<slot name="right">
				{#if iconRight}
					<div>
						<Icon icon={iconRight} />
					</div>
				{/if}
			</slot>
		</div>
	</fieldset>
	<Text colour="red" size="sm">
		{#if validationMessage}
			{validationMessage}
		{:else}
			&nbsp;
		{/if}
	</Text>
</div>
