import React from 'react';
import { SnackbarProvider } from 'notistack';
import { makeStyles } from '@material-ui/core/styles';
import ErrorIconSVG from 'assets/images/svg/ErrorIconSVG';
import InfoIconSVG from 'assets/images/svg/InfoIconSVG';
import SuccessIconSVG from 'assets/images/svg/SuccessIconSVG';

const useStyles = makeStyles((theme) => ({
    root: {
        '& > div': {
            minWidth: 360,
            maxWidth: 400,
            boxShadow: 'none',
            padding: `6px 21px`,
            fontSize: '0.875rem',
            borderRadius: 4,
            display: 'flex',
            alignItems: 'center',
            '& .MuiSnackbarContent-message': {
                flexBasis: '90%',
                '& svg': {
                    marginRight: 8,
                    minWidth: 20
                }
            },
            '& .MuiSnackbarContent-action': {
                flexBasis: '10%',
                padding: 0
            }
        }
    },
    success: {
        background: '#96C060',
        color: theme.colors.white
    },
    error: {
        background: '#E86E5E',
        color: theme.colors.white
    },
    warning: {
        background: '#E86E5E',
        color: theme.colors.white
    },
    info: {
        background: '#353445',
        color: theme.colors.white
    }
}));

function NotifierProvider({ children }) {
    const classes = useStyles();
    return (
        <div></div>
        // <SnackbarProvider
        //     maxSnack={3}
        //     anchorOrigin={{
        //         vertical: "bottom",
        //         horizontal: "center"
        //     }}
        //     classes={{
        //         root: classes.root,
        //         variantSuccess: classes.success,
        //         variantError: classes.error,
        //         variantWarning: classes.warning,
        //         variantInfo: classes.info
        //     }}
        //     iconVariant={{
        //         default: <InfoIconSVG />,
        //         error: <ErrorIconSVG />,
        //         success: <SuccessIconSVG />,
        //         info: <InfoIconSVG />,
        //         warning: <ErrorIconSVG />
        //     }}
        // >
        //     {children}
        // </SnackbarProvider>
    );
}
export default React.memo(NotifierProvider);
