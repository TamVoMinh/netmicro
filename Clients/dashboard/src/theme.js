import hexToRgba from "hex-to-rgba";

const defaultTheme = {
    spacing: factor => [0, 4, 8, 14, 24, 32, 64][factor],
    colors: {
        lavender: "#4D3F8A",
        darkLavender: "#392B76",
        lightLavender: "#7869B9",
        paleLavender: "#A69FC4",
        solitude: "#EBEBF6",
        paleNavy: "#F3F4FC",
        codeHeader: `#787791`,

        burntSlena: "#EA6A46",
        crusta: "#F9772A",
        sun: "#F8AD13",
        atlantis: "#77B32B",
        dodgerBlue: "#2D97F2",
        funBlue: "#1D66AE",
        shipCove: "#6A7AB9",
        shamRock: "#2DD2A3",
        froly: "#F67B8E",
        fuchsiaBlue: "#6E5BBE",
        black: "#000000",
        greySuit: "#8C84AF",

        primaryText: "#2A293A",
        secondaryText: "#93929E",
        dimGrey: "#2a293a",
        steel: "#78778B",
        midGrey: "#93929E",
        lightGreyBlue: "#ACADB9",
        disabledGrey: "#C9C9CE",
        silver: "#D7D7DC",
        lightGrey: "#DBDCE1",
        divider: "#E9EAEF",
        paleGrey: "#F4F5F7",
        ghostwhite: "#F7F8FA",
        white: "#FFFFFF",
        border: "#D7D7DC",
        background: "#F7F8FA",
        disabledText: "#C9C9CE",
        disabledButtonBackground: "#dbdce1",
        disabledButtonColor: "#ffffff",
        highlight: "#4A91E2",
        hoverItem: "#f7f8fa",
        hoverAddItem: "#7869b9",
        skeletonColor: "#F4F5F7",
        selectionColor: "#F6F9FD",
        seaGreen: "#42B883",
        checkboxBorder: "#b4bdc8",
        iconGridUIColor: "#78778B",
        resizeColor: "#93929E",
        snackBarColor: "#353445",
        iconHeaderColor: hexToRgba("#78778B", 0.6)
    },
    typography: {
        fontFamily:
            'Roboto, apple-system, BlinkMacSystemFont, "PingFang SC", "Hiragino Sans GB", "Microsoft YaHei",SimSun, sans-serif;',
        title: {
            fontSize: "2.875rem",
            color: "#251555",
            fontFamily:
                'Roboto, apple-system, BlinkMacSystemFont, "PingFang SC", "Hiragino Sans GB", "Microsoft YaHei",SimSun, sans-serif;',
            lineHeight: 1,
            fontWeight: 300
        },
        h1: {
            fontSize: "3rem",
            color: "#251555",
            fontWeight: 300
        },
        h2: {
            fontSize: "1.875rem",
            color: "#2A293A",
            fontWeight: "normal"
        },
        h3: {
            fontSize: "1.5rem",
            color: "#2A293A",
            fontWeight: "bold"
        },
        h3Regular: {
            fontSize: "1.5rem",
            color: "#2A293A",
            fontWeight: "normal"
        },
        h4: {
            fontSize: "0.875rem",
            color: "#2A293A",
            fontWeight: 500
        },
        button: {
            textTransform: "normal"
        },
        body2: {
            fontWeight: "normal",
            color: "#2A293A",
            fontSize: "0.875rem"
        },
        caption: {
            fontSize: "0.875rem",
            color: "#acadb9",
            fontWeight: "normal"
        }
    }
};

export default defaultTheme;
