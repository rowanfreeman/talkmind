import { getContext, type ComponentEvents } from 'svelte';
import type Eventbus from '.';
import type { Content, MessageId, Party } from '$lib/components/Conversation';

type EventKeys = keyof ComponentEvents<Eventbus>;

export type ConnectEvent = ApplicationEvent<'connect', void>;
export type DisconnectEvent = ApplicationEvent<'disconnect', void>;
export type SpeechRecognitionStartedEvent = ApplicationEvent<
	'speechRecognitionStarted',
	{
		content: Content;
		partyId: Party['id'];
		id: MessageId;
	}
>;

export interface ApplicationEvent<TEventKey extends EventKeys = EventKeys, TArgs = unknown> {
	name: TEventKey;
	args?: TArgs;
}

type ExtractApplicationEventArgs<TEvent extends ApplicationEvent> = TEvent extends ApplicationEvent<
	any,
	infer TArgs
>
	? TArgs
	: never;

type Publish = <TEvent extends ApplicationEvent>(
	eventName: TEvent['name'],
	args?: ExtractApplicationEventArgs<TEvent>,
) => Promise<void>;

export type Callback<TEvent extends ApplicationEvent | unknown = ApplicationEvent> = (
	event: TEvent,
) => Promise<void> | void;

type Subscribe = (callback: Callback) => Unsubscribe;

type Unsubscribe = VoidFunction;

export interface EventBus {
	publish: Publish;
	subscribe: Subscribe;
}

export const useEventBus = () => getContext<EventBus>('EventBus');
