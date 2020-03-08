import React from 'react';
import { Grid } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Collapse from '@material-ui/core/Collapse';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import DashboardIcon from '@material-ui/icons/DashboardOutlined';
import AccountCircle from '@material-ui/icons/AccountCircle';
import MoneyIcon from '@material-ui/icons/MoneyOutlined';
import ReportIcon from '@material-ui/icons/ReportOutlined';
import InfoIcon from '@material-ui/icons/InfoOutlined';
import ClearIcon from '@material-ui/icons/ClearOutlined';
import { withRouter } from 'react-router-dom';

const useStyles = makeStyles(theme => ({
    root: {
        width: '100%',
        maxWidth: 360,
        backgroundColor: theme.palette.background.paper
    },
    nested: {
        paddingLeft: theme.spacing(4)
    },
    activeLink: {
        background: theme.palette.primary.main,
        '& *': {
            color: theme.colors.white
        }
    },
    navigationItem: {
        '&:hover': {
            background: theme.palette.primary.main,
            '& *': {
                color: theme.colors.white
            }
        }
    }
}));
const menu = [
    {
        id: 1,
        title: 'Dashboard',
        icon: () => <DashboardIcon />,
        value: 'dashboard',
        path: '/dashboard',
        children: [
            { title: 'Revenue', icon: () => <MoneyIcon />, path: '/revenue', value: 'revenue' },
            { title: 'Report', icon: () => <ReportIcon />, path: '/report', value: 'report' }
        ]
    },
    {
        id: 2,
        title: 'User',
        path: '/user',
        value: 'user',
        icon: () => <AccountCircle />,
        children: [
            { title: 'Info', icon: () => <InfoIcon />, path: '/user/info', value: 'info' },
            { title: 'Change Password', icon: () => <ClearIcon />, path: '/user/reset', value: 'reset' }
        ]
    }
];

let defaultOPen = {};
menu.forEach(item => {
    defaultOPen[item.id] = true;
});

function MenuBar({ history, location }) {
    const classes = useStyles();
    let partials = location.pathname.split('/');
    const last = partials[partials.length - 1];

    const [open, setOpen] = React.useState(defaultOPen);

    const handleClick = ({ e, id }) => {
        e.stopPropagation();
        setOpen({
            ...open,
            [id]: !open[id]
        });
    };

    const navigate = path => {
        history.push(path);
    };

    return (
        <Grid container>
            <List component="nav" aria-labelledby="nested-list-subheader" className={classes.root}>
                {menu.map(({ title, icon, path, value, children = [], id }) => {
                    const activeLink = last.includes(value);
                    return (
                        <>
                            <ListItem
                                key={id}
                                className={`${classes.navigationItem} ${activeLink ? classes.activeLink : ''}`}
                                button
                                onClick={() => navigate(path)}
                            >
                                <ListItemIcon>{icon && icon()}</ListItemIcon>
                                <ListItemText primary={title} />
                                {children.length > 0 && open[id] ? (
                                    <ExpandLess onClick={e => handleClick({ e, id })} />
                                ) : (
                                    <ExpandMore onClick={e => handleClick({ e, id })} />
                                )}
                            </ListItem>
                            {children.length > 0 && (
                                <Collapse in={open[id]} timeout="auto" unmountOnExit>
                                    <List component="div" disablePadding>
                                        {children.map(nestedItem => {
                                            const activeNestedLink = last.includes(nestedItem.value);
                                            return (
                                                <ListItem
                                                    key={nestedItem.value}
                                                    button
                                                    className={`${classes.navigationItem} ${classes.nested} ${
                                                        activeNestedLink ? classes.activeLink : ''
                                                    }`}
                                                    onClick={() => navigate(nestedItem.path)}
                                                >
                                                    <ListItemIcon>{nestedItem.icon && nestedItem.icon()}</ListItemIcon>
                                                    <ListItemText primary={nestedItem.title} />
                                                </ListItem>
                                            );
                                        })}
                                    </List>
                                </Collapse>
                            )}
                        </>
                    );
                })}
            </List>
        </Grid>
    );
}
export default withRouter(MenuBar);
