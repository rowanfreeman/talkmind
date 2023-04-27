const requestMicrophoneAccess = async () => {
	try {
		await navigator.mediaDevices.getUserMedia({
			audio: true,
		});

		return true;
	} catch {
		return false;
	}
};

let mediaRecorder: MediaRecorder | undefined = undefined;
type OnFinish = (data: BlobEvent) => Promise<void>;
type StartRecording = (onFinish: OnFinish) => Promise<void>;
type StopRecording = () => void;

const start: StartRecording = async (onFinish) => {
	const stream = await navigator.mediaDevices.getUserMedia({
		audio: true,
	});

	mediaRecorder = new MediaRecorder(stream, { mimeType: 'audio/webm' });
	mediaRecorder.ondataavailable = onFinish;
	mediaRecorder.start();
};

const stop: StopRecording = () => mediaRecorder?.stop();

const useMediaRecorderService = () => ({
	requestMicrophoneAccess,
	start,
	stop,
});

export default useMediaRecorderService;
export type { StartRecording, StopRecording };
