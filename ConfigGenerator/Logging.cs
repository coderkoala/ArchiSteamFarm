﻿/*
    _                _      _  ____   _                           _____
   / \    _ __  ___ | |__  (_)/ ___| | |_  ___   __ _  _ __ ___  |  ___|__ _  _ __  _ __ ___
  / _ \  | '__|/ __|| '_ \ | |\___ \ | __|/ _ \ / _` || '_ ` _ \ | |_  / _` || '__|| '_ ` _ \
 / ___ \ | |  | (__ | | | || | ___) || |_|  __/| (_| || | | | | ||  _|| (_| || |   | | | | | |
/_/   \_\|_|   \___||_| |_||_||____/  \__|\___| \__,_||_| |_| |_||_|   \__,_||_|   |_| |_| |_|

 Copyright 2015-2016 Łukasz "JustArchi" Domeradzki
 Contact: JustArchi@JustArchi.net

 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at

 http://www.apache.org/licenses/LICENSE-2.0
					
 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.

*/

using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ConfigGenerator.Properties;

namespace ConfigGenerator {
	internal static class Logging {
		internal static void LogGenericInfo(string message) {
			if (string.IsNullOrEmpty(message)) {
				return;
			}

			MessageBox.Show(message, Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		internal static void LogGenericError(string message, [CallerMemberName] string previousMethodName = "") {
			if (string.IsNullOrEmpty(message)) {
				return;
			}

			MessageBox.Show(previousMethodName + @"() " + message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		internal static void LogGenericException(Exception exception, [CallerMemberName] string previousMethodName = "") {
			while (true) {
				if (exception == null) {
					return;
				}

				MessageBox.Show(previousMethodName + @"() " + exception.Message + Environment.NewLine + exception.StackTrace, Resources.Exception, MessageBoxButtons.OK, MessageBoxIcon.Error);

				if (exception.InnerException != null) {
					exception = exception.InnerException;
					continue;
				}

				break;
			}
		}

		internal static void LogGenericWarning(string message, [CallerMemberName] string previousMethodName = "") {
			if (string.IsNullOrEmpty(message)) {
				return;
			}

			MessageBox.Show(previousMethodName + @"() " + message, Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}
