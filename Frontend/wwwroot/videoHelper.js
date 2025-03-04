window.playVideo = (videoId) => {
    setTimeout(() => {
        let video = document.getElementById(videoId);
        if (video) {
            video.play().catch(error => console.error("Autoplay blocked:", error));
        }
    }, 500); // 500ms delay to let Blazor finish rendering
};
