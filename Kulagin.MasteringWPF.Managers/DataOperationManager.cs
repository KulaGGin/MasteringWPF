using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels;
using Kulagin.MasteringWPF.Managers.Interfaces;


namespace Kulagin.MasteringWPF.Managers {
    public class DataOperationManager {
        private const int maximumRetryCount = 2;
        private IUiThreadManager uiThreadManager;

        public DataOperationManager(IUiThreadManager uiThreadManager) {
            UiThreadManager = uiThreadManager;
        }

        private IUiThreadManager UiThreadManager { get { return uiThreadManager; } set { uiThreadManager = value; } }
        private FeedbackManager FeedbackManager { get { return FeedbackManager.Instance; } }

        public GetDataOperationResult<TResult> TryGet<TResult>(
                                                Func<TResult> method,
                                                string successText,
                                                string errorText,
                                                bool isMessageSupressed
                                               ) {
            Debug.Assert(method != null,
                         "The method input parameter of the DataOperationManager.TryGet<TResult>() method must not be null.");

            for (int index = 0; index < maximumRetryCount; index++) {
                try {
                    TResult result = method();
                    return WithFeedback(
                            new GetDataOperationResult<TResult>(result, successText),
                            isMessageSupressed
                           );
                }
                catch (Exception exception) {
                    if (index == maximumRetryCount - 1) {
                        return WithFeedback(
                                new GetDataOperationResult<TResult>(exception, errorText),
                                isMessageSupressed
                               );
                    }

                    Task.Delay(TimeSpan.FromMilliseconds(300));
                }
            }

            return WithFeedback(
                    new GetDataOperationResult<TResult>(default(TResult), successText),
                    isMessageSupressed
                   );
        }

        private GetDataOperationResult<TResult> WithFeedback<TResult>(
                                                 GetDataOperationResult<TResult> dataOperationResult,
                                                 bool isMessageSupressed
                                                ) {
            if (isMessageSupressed && dataOperationResult.IsSuccess)
                return dataOperationResult;

            FeedbackManager.Add(dataOperationResult, false);
            return dataOperationResult;
        }

        public Task<GetDataOperationResult<TResult>> TryGetAsync<TResult>(
            Func<TResult> method, string successText, string errorText,
            bool isMessageSupressed) {
            return UiThreadManager.RunAsynchronously(
                              () => TryGet(method, successText, errorText, isMessageSupressed)
                              );
        }

        public SetDataOperationResult TrySet(Action method, string successText, string errorText, bool isMessagePermanent, bool isMessageSupressed) {
            Debug.Assert(method != null, "The method input parameter of the DataOperationManager.TrySet<TResult>() method must not be null.");

            for (int index = 0; index < maximumRetryCount; index++) {
                try {
                    method();
                    return WithFeedback(
                            new SetDataOperationResult(successText),
                            isMessagePermanent,
                            isMessageSupressed
                           );
                }
                catch (Exception exception) {
                    if (index == maximumRetryCount - 1) {
                        return WithFeedback(
                                new SetDataOperationResult(exception, errorText),
                                isMessagePermanent,
                                isMessageSupressed
                               );
                    }

                    Task.Delay(TimeSpan.FromMilliseconds(300));
                }
            }

            return WithFeedback(
                    new SetDataOperationResult(successText),
                    isMessagePermanent,
                    isMessageSupressed
                   );
        }

        private SetDataOperationResult WithFeedback(
                                        SetDataOperationResult dataOperationResult,
                                        bool isMessagePermanent,
                                        bool isMessageSupressed
                                       ) {

            if (isMessageSupressed && dataOperationResult.IsSuccess)
                return dataOperationResult;

            FeedbackManager.Add(dataOperationResult, isMessagePermanent);

            return dataOperationResult;
        }

        public Task<SetDataOperationResult> TrySetAsync(Action method) {
            return TrySetAsync(method, string.Empty, string.Empty);
        }

        public Task<SetDataOperationResult> TrySetAsync(Action method, string successText, string errorText) {
            return TrySetAsync(method, successText, errorText, false, false);
        }

        public Task<SetDataOperationResult> TrySetAsync(Action method,
                                                        string successText, string errorText, bool isMessagePermanent,
                                                        bool isMessageSupressed) {
            return UiThreadManager.RunAsynchronously(
                                    () => TrySet(method, successText, errorText, isMessagePermanent, isMessageSupressed)
                                   );
        }
    }
}