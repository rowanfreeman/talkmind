enum MessageTypes {
	Self,
	Other,
}

type MessageType = Lowercase<keyof typeof MessageTypes>;

export { MessageTypes, type MessageType };
