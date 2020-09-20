import React from "react";

function SuccessIconSVG({ color = "#FFFFFF", ...other }) {
    return <svg width="20px" height="21px" viewBox="0 0 20 21" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlnsXlink="http://www.w3.org/1999/xlink">
        <title>Success</title>
        <desc>Created with Sketch.</desc>
        <g id="Styleguide" stroke="none" strokeWidth="1" fill="none" fillRule="evenodd">
            <g id="GridUI-Style-Guide" transform="translate(-169.000000, -4942.000000)" fill={color} fillRule="nonzero">
                <g id="Success" transform="translate(169.000000, 4942.257812)">
                    <path d="M2.92873302,2.92873302 C6.83436255,-0.976461728 13.166065,-0.976026948 17.0712597,2.92873302 C20.9755849,6.83436255 20.9760197,13.1656302 17.0712597,17.0712597 C13.1656302,20.9760197 6.83392777,20.9755849 2.92873302,17.0712597 C-0.976026948,13.1656302 -0.976461728,6.83392777 2.92873302,2.92873302 Z M14.5424987,7.00113485 C14.1411479,6.58703138 13.5077696,6.55745257 13.073439,6.91239839 L12.9769385,7.00113485 L9.06376812,11.0386437 C8.97267845,11.1322689 8.8345084,11.1478731 8.72784599,11.0854563 L8.66825817,11.0386437 L7.22306149,9.54774204 C6.79083755,9.10178446 6.08951664,9.10178446 5.65750129,9.54774204 C5.25615049,9.96164565 5.22748257,10.6151348 5.57149755,11.063265 L5.65750129,11.1628317 L8.08312874,13.6655318 C8.48428585,14.0796353 9.1176503,14.1092141 9.5521469,13.7542683 L9.64868894,13.6655318 L14.5424987,8.61622447 C14.750058,8.40207013 14.8666667,8.11150896 14.8666667,7.80867966 C14.8666667,7.50585036 14.750058,7.21528919 14.5424987,7.00113485 Z" id="Shape"></path>
                </g>
            </g>
        </g>
    </svg>
}

export default React.memo(SuccessIconSVG);